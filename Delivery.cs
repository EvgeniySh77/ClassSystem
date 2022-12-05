using System;

namespace ClassSystem
{
    abstract class Delivery
    {
        public string address;
        static public string[] deliveryTypes;


        public Delivery(string address, string[] deliveryTypes)
        {
            this.address = address;
            Delivery.deliveryTypes = deliveryTypes; 
        }

        public static void ShowDeliveryTypes()
        {
            int i = 0;
            Console.Clear();
            Console.WriteLine("+" + new string('-', 44) + "+");
            foreach (var item in deliveryTypes)
            {
                Console.Write($"| {++i} - {item}");
                Console.SetCursorPosition(45, i);
                Console.WriteLine("|");
            }
            Console.WriteLine("+" + new string('-', 44) + "+");
        }

        public static string ChooseDelivery(out int deliveryNumber)
        {            
            Console.Write("Выберите номер доставки... ");

            bool flag = false;
            while (true)
            {
                flag = int.TryParse(Console.ReadLine(), out deliveryNumber);
                if (--deliveryNumber >= 0 && deliveryNumber < deliveryTypes.Length && flag)
                {
                    deliveryNumber = Array.IndexOf(deliveryTypes, deliveryTypes[deliveryNumber]);
                    break;
                }
                else Console.Write("Не верный ввод, попробуйте еще... ");                
            }
            return deliveryTypes[deliveryNumber];
        }

        abstract public void DeliverGoods();
    }
}
