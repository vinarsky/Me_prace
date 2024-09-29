using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mail_Bomber
{
    internal class CustomerSimulation
    {
        Random r = new Random();
        /// <summary>
        /// PDF files that were send.
        /// </summary>
        public List<Order> Orders = new List<Order>();

        /// <summary>
        /// List of direction an order can have
        /// </summary>
        List<string> Directions = new List<string>();

        /// <summary>
        /// List of changes that are alowed to send. Defined be user.
        /// </summary>
        public List<string> ChangesToSend;

        /// <summary>
        /// Interval in seconds in which mails are send, is renewed every simulation loop
        /// </summary>
        private int Interval;

        /// <summary>
        /// Amount of pdf files that are avaliable to send;
        /// </summary>
        int Amount_of_IMPorders = Directory.GetFiles(@"../../Mails/Objednavky/Import", "*.pdf").Length;
        int Amount_of_EXPorders = Directory.GetFiles(@"../../Mails/Objednavky/Export", "*.pdf").Length;

        /// <summary>
        /// MilaSender is used for sending mail... obviously...
        /// </summary>
        public MailSender MailSender = new MailSender();

        /// <summary>
        /// Instance of the main form
        /// </summary>
        MainMenu MainMenuInstance;

        /// <summary>
        /// 
        /// </summary>
        public SmallInfoPanel SmallInfoPanel;

        /// <summary>
        /// Simulation runs or not, is true even when the sim is pause, false when the sim in terminated completely 
        /// </summary>
        public bool Ongoing = false;
        public bool IsPaused = false;

        /// <summary>
        /// Aqures when Simulation is complete.
        /// </summary>
        public event Action SimulationCompleted;

        /// <summary>
        /// Aqures when when mail is send.
        /// </summary>
        public event Action<Order, Change> MailSend;

        public CustomerSimulation(MainMenu MainMenu)
        {
            this.MainMenuInstance = MainMenu;
        }


        /// <summary>
        /// Adds new pdf file to the list of files that were already sent. Prevents application from sending the same order more then once.
        /// </summary>
        /// <returns>Either returns new order or null when there was no more orders to sent</returns>
        Order Add_To_New_PDF_To_Orders()
        {
            Order order = PickRandomPDFfile();
            if (!IsInPDFfilesList(order))
            {
                Orders.Add(order);
                return order;
            }
            return null;

        }


        /// <summary>
        /// Checks if an file name is in list of order that were already sent.
        /// </summary>
        /// <param name="filename">name of an file to look for in the list</param>
        /// <returns>returns true if file's name is found, false in not found</returns>
        bool IsInPDFfilesList(Order o)
        {
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].Equals(o))
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Desides either a new order will be send next or a change to an existing order.
        /// </summary>
        string SendChangeOrOrder()
        {
            if (Orders.Count == 0)
                return "Order";

            int ChangeIntesity = int.Parse(ReadAppConf.ReadSettings("ChangesIntensity"));
            if (ChangeIntesity < 0 || ChangeIntesity > 3)
                throw new Exception("Change intensity může být mezi 0 a 3");
            if (ChangeIntesity <= r.Next(5))
            {
                return "Order";
            }
            else
            {
                return "Change";
            }
        }


        /// <summary>
        /// Pickes a random pdf file from 'Objednavky' folder.
        /// </summary>
        Order PickRandomPDFfile()
        {
            string IMPorEXP = PickRandomImportOrExportFolder();
            string[] pdfFiles = Directory.GetFiles(@"../../Mails/Objednavky/" + IMPorEXP, "*.pdf");
            int i = r.Next(pdfFiles.Length);
            string chosen_file = pdfFiles[i].Split('/')[4];
            return new Order(chosen_file);
        }


        /// <summary>
        /// Picks what type of orders to send
        /// </summary>
        /// <returns>string of import or export</returns>
        string PickRandomImportOrExportFolder()
        {
            if (MainMenuInstance.ExportOrderCheckBox.Checked && !MainMenuInstance.ImportOrderCheckBox.Checked)
                return "Export";
            else if (MainMenuInstance.ImportOrderCheckBox.Checked && !MainMenuInstance.ExportOrderCheckBox.Checked)
                return "Import";
            else
            {
                int decider = r.Next(2);
                if (decider == 0)
                    return "Export";
                else
                    return "Import";
            }
        }


        /// <summary>
        /// Picks a random folder name from list ChangesToSend. 
        /// </summary>
        /// <returns>Returns folder name</returns>
        string PickRandomChangeFolder()
        {
            return ChangesToSend[r.Next(ChangesToSend.Count)];
        }


        /// <summary>
        /// Picks a random change from folder that user wants to test.
        /// </summary>
        Change PickRandomChange()
        {
            string folder = PickRandomChangeFolder();
            string[] FilesToSend = Directory.GetFiles(@"../../Mails/" + folder, "*.msg");
            int i = r.Next(FilesToSend.Length);
            string chosen_file = FilesToSend[i].Split('\\')[1];
            return new Change(folder, chosen_file);
        }


        /// <summary>
        /// In the begining of every simultion, this method has to be executed
        /// </summary>
        /// <returns>returns the amount of orders that can be send</returns>
        private int OnSimulatoinStart()
        {
            int Amount_of_orders_that_are_avaliable_to_send = 0;
            if (MainMenuInstance.ExportOrderCheckBox.Checked && !MainMenuInstance.ImportOrderCheckBox.Checked)
                Amount_of_orders_that_are_avaliable_to_send = Amount_of_EXPorders;
            else if (MainMenuInstance.ImportOrderCheckBox.Checked && !MainMenuInstance.ExportOrderCheckBox.Checked)
                Amount_of_orders_that_are_avaliable_to_send = Amount_of_IMPorders;
            else if (MainMenuInstance.ExportOrderCheckBox.Checked && MainMenuInstance.ImportOrderCheckBox.Checked)
                Amount_of_orders_that_are_avaliable_to_send = Amount_of_IMPorders + Amount_of_EXPorders;
            else
                Amount_of_orders_that_are_avaliable_to_send = 0;

            ChangesToSend = ReadAppConf.ReadWhatChangesToSend();
            Ongoing = true;
            IsPaused = false;
            return Amount_of_orders_that_are_avaliable_to_send;
        }

         
        /// <summary>
        /// Stars the simulation of customers sending mails. VIP!
        /// </summary>
        public async void StartSimulation()
        {
            int i = OnSimulatoinStart();           

            while (Orders.Count < i && Ongoing)
            {
                Interval = ReadAppConf.ReadInterval();
                while (IsPaused)
                {
                    Thread.Sleep(2000);
                }
                if (SendChangeOrOrder() == "Order")
                {
                    Order o = null;
                    do
                    {
                        o = Add_To_New_PDF_To_Orders();
                    } while (o == null);
                    if (Ongoing)
                    {
                        OnMailSend(o, new Change());
                        await MailSender.SendOrderPDFfile(o, SmallInfoPanel);                                                      
                    }
                }
                else
                {
                    Change c = null;
                    Order or = null;
                    do
                    {
                        c = PickRandomChange();
                        or = Orders[r.Next(Orders.Count)];
                    } while (or.IsInChangesAlreadySent(c));
                    or.AddToChangesAlreadySent(c);
                    if (Ongoing)
                    {
                        OnMailSend(or, c);
                        await MailSender.SendOrderChange(or, c);
                    }

                }
                Thread.Sleep(Interval);
            }
            //await MailSender.SendTestEmail();
            Orders.Clear();
            OnSimulationCompleted();
        }

        protected virtual void OnSimulationCompleted()
        {
            SimulationCompleted?.Invoke();
        }
        protected virtual void OnMailSend(Order o, Change c)
        {
            MailSend?.Invoke(o, c);
        }
    }
}
