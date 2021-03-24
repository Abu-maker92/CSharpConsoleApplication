using ProjectA.DTO;
using ProjectA.Repository;
using ProjectA.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.MyApp
{
    class AppProducts : IMyApps
    {
        IRepository<Products> repo = new RepoProducts();
        public ActionType Action { get; set; }

        public void AboutThisProject()
        {
            ConColor Col = new ConColor();
            Col.WriteMessage("\nWelcome to my First Project.\nThis is the project where you can act many operations. Basically It's my first project about CRUD on C#", MessageType.Success);
            //Console.WriteLine("\nWelcome to my First Project.\nThis is the project where you can act many operations. Basically It's my first project about CRUD on C#");
        }

        public void AddNewItemAction()
        {
            Products obj = new Products();
            Console.Write("Enter a Product Name: ");
            obj.ProductName = Console.ReadLine();


            Console.Write("Enter theproduct Is Active: true or false: ");
            obj.IsActive = bool.Parse(Console.ReadLine());

            Console.Write("Enter the Product Warranty: ");
            obj.Warranty = Console.ReadLine();

            Console.Write("Enter the Product Price: ");
            obj.Price = long.Parse(Console.ReadLine());


            obj = repo.Add(obj);
            Console.WriteLine("\nThe Product is Succesfully added. \nYour Product Id is: {0}", obj.ProductID);

        }

        public void DeleteByIDAction()
        {
            Products obj = new Products();
            Console.Write("Enter a valid ID: ");
            long id = long.Parse(Console.ReadLine());
            repo.Remove(id);
            if (repo.Remove(id))
            {

                Console.WriteLine("The Entered Id is Removed");
            }

            else
            {
                Console.WriteLine("The Entered Id is not Here");
            }

        }

        public void DevelopedBy()
        {
            Console.WriteLine("\n\tThe Project is developed by Abu Bokor Siddik. \n\tTraineeID  : 1257461.\n\tBatch ID   : ESAD-CS/USSL/44/01.\n\tTspCentre  : US-Software Limited.");



        }

        public void ManageAllAction()
        {
            switch (Action)
            {


                case ActionType.ShowAllData:
                    this.ShowAllDataAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.SearchByID:
                    this.SearchByIDAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.SearchByName:
                    this.SearchByNameAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.AddNewItem:
                    this.AddNewItemAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.UpdateByID:
                    this.UpdateByIDAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.DeleteByID:
                    this.DeleteByIDAction();
                    this.WaitForGoBack();
                    break;
                case ActionType.AboutThisProject:
                    this.AboutThisProject();
                    this.WaitForGoBack();
                    break;
                case ActionType.DevelopedBy:
                    this.DevelopedBy();
                    this.WaitForGoBack();
                    break;
                default:
                    Console.WriteLine("Please Enter Valid Operation");
                    this.WaitForGoBack();
                    break;
            }
        }

        public void ReadMenuSelection()
        {
            try
            {
                string key;
                do
                {
                    Console.Clear();
                    this.ShowMenu();
                    Console.Write("Please Enter a Action Number: [S to Stop]: \n");
                    key = Console.ReadLine();
                    if (key.ToLower() != "S")
                    {
                        int temp = 0;
                        temp = int.Parse(key);
                        Action = (ActionType)temp;
                        Console.Clear();
                        this.ManageAllAction();
                    }
                } while (key.ToLower() != "S");
            }
            catch (Exception ex)
            {

            }

        }

        public void SearchByIDAction()
        {
            Console.Write("\nEnter a Product ID: ");
            int id = int.Parse(Console.ReadLine());
            var Data = repo.Get(id);
            if (Data != null)
            {
                Console.WriteLine($"    {Data.ProductID} {Data.ProductName} {Data.IsActive} {Data.Warranty} {Data.Price}");
            }
            else if (Data == null)
            {
                Console.WriteLine("You enter a invalid ID.");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }

        public void SearchByNameAction()
        {
            Console.Write("\nEnter a Product Name: ");
            string Name = Console.ReadLine();
            var Data = repo.Name(Name);
            if (Name != null)
            {
                Console.WriteLine($"    {Data.ProductID} {Data.ProductName} {Data.IsActive} {Data.Warranty} {Data.Price}");
            }
            else if (Name == null)
            {
                Console.WriteLine("You enter a invalid ID.");
            }
        }

        public void ShowAllDataAction()
        {
            var items = repo.GetAll();
            foreach (var obj2 in items)
            {
                Console.WriteLine($"    {obj2.ProductID} {obj2.ProductName} {obj2.IsActive} {obj2.Warranty} {obj2.Price}");
            }

        }

        public void ShowMenu()
        {
            Array ShowOutput = Enum.GetValues(typeof(ActionType));
            foreach (var En in ShowOutput)
            {
                Console.WriteLine("     " + (int)En + ")" + En);
            }
        }

        public void UpdateByIDAction()
        {
            Console.Write("Press any key to show all data:  ");
            string name = Console.ReadLine();

            this.ShowAllDataAction();
            Console.Write("\nDo you want to update? ");
            Console.Write("\nPress any key to update...\n");
            this.WaitForGoBack();

            Products obj2 = new Products();
            ConColor obj = new ConColor();
            obj.WriteMessage("Enter a valid ID: ", MessageType.Warning);
            obj2.ProductID = long.Parse(Console.ReadLine());


            obj.WriteMessage("\nEnter your Product Name: ", MessageType.Warning);
            obj2.ProductName = Console.ReadLine();

            obj.WriteMessage("Enter theproduct Is Active: true or false: ", MessageType.Warning);
            obj2.IsActive = bool.Parse(Console.ReadLine());

            obj.WriteMessage("Enter the Product Warranty: ", MessageType.Warning);
            obj2.Warranty = Console.ReadLine();

            obj.WriteMessage("Enter the Product Price: ", MessageType.Warning);
            obj2.Price = long.Parse("0" + Console.ReadLine());


            repo.Update(obj2);
            obj.WriteMessage("\nThe Product is Succesfully Updated.", MessageType.Success);


        }

        public void WaitForGoBack()
        {
            string Back = "";
            do
            {
                Console.WriteLine("\nTo Go Back Press 'Q'  then Enter...");
                Back = Console.ReadLine();
                if (Back.ToLower() != "q")
                {
                    return;
                }
            }
            while (Back.ToLower() != "q");
        }
    }
}
