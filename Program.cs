using System;
using System.Collections.Generic;

namespace ClassSystem
{
    internal class Program
    {
        static string[] deliveryTypes = {
            "Доставка на дом",
            "Доставка в пункт самовывоза",
            "Доставка в магазин"
        };
        static string[] householdGoods = { 
            "Перчатки резиновые",
            "Туалетная бумага",
            "Мешки для мусора",
            "Щетка-сметка для снега"
        };
        static string[] electricalGoods = {
            "Счётчик электроэнергии \"Меркурий\"",
            "Батарейка алкалиновая \"GP\"",
            "Розетка накладная \"Schneider Electric\"",
            "Конвектор электрический \"Equation\""
        };
        static string[] buildGoods = {
            "Штукатурка гипсовая \"Vetonit Easy\"",
            "Плитка декоративная \"White Hills\"",
            "Клей-пена \"Penoplex Fastfix\"",
            "Звукоизоляция \"Rockwool\""
        };
        public static string[] productType = {
            "Хозтовары",
            "Электротовары",
            "Стройтовары",
            "Продукты"
        };
        
        static void Main()
        {
            string productName = null;
            int number = 0;
            int key = -1;
            bool selector = true;
            var hgProduct = new Product<HouseholdGoods>(new HouseholdGoods(householdGoods));
            var egProduct = new Product<ElectricalGoods>(new ElectricalGoods(electricalGoods));
            var bgProduct = new Product<BuildGoods>(new BuildGoods(buildGoods));

            Product<string[]>.PrintProduct(productType, key);
            Console.Write("Выберите номер раздела товаров... ");
            while (selector)
            {            
                int value;
                bool flag;
                while (true)
                {                
                    flag = int.TryParse(Console.ReadLine(), out value);
                    if (--value >= 0 && value < productType.Length && flag)
                    {
                        key = Array.IndexOf(productType, productType[value]);
                        break;
                    }
                    else Console.Write("Не верный ввод, попробуйте еще... "); 
                }

                if (key == -1)
                    Console.WriteLine("Извините, такого раздела товаров нет...");
                else
                {
                    switch (key)
                    {
                        case 0:
                            {
                                Product<HouseholdGoods>.PrintProduct(hgProduct.product.productName, key);
                                productName = hgProduct.ChooseProduct(hgProduct.product.productName, out number);                                
                                selector = false;
                                break;
                            }
                        case 1:
                            {
                                Product<ElectricalGoods>.PrintProduct(egProduct.product.productName, key);
                                productName = egProduct.ChooseProduct(egProduct.product.productName, out number);                                
                                selector = false;
                                break;
                            }
                        case 2:
                            {
                                Product<BuildGoods>.PrintProduct(bgProduct.product.productName, key);
                                productName = bgProduct.ChooseProduct(bgProduct.product.productName, out number);                                
                                selector = false;
                                break;
                            }
                        default:
                            Console.WriteLine("Извините, в этом разделе товаров пока нет...");
                            Console.Write("Выберите другой раздел...");                            
                            break;
                    }
                }
            }
            string delivery;
            Delivery.deliveryTypes = deliveryTypes;
            Delivery.ShowDeliveryTypes();
            Console.WriteLine($"Вы выбрали товар, под номером {++number} - \"{productName}\"");
            delivery = Delivery.ChooseDelivery(out _);

            switch (delivery)
            {
                case "Доставка на дом":
                    {
                        Order<HomeDelivery, string> order = new Order<HomeDelivery, string>();
                        Console.WriteLine("Введите на какой адрес доставить товар...");
                        order.address = Console.ReadLine();
                        order.delivery = new HomeDelivery(order.address);
                        order.delivery.DeliverGoods();
                        break;
                    }
                case "Доставка в пункт самовывоза":
                    {
                        Order<PickPointDelivery, string> order = new Order<PickPointDelivery, string>();                        
                        order.address = "Южное шоссе, 55к3, Санкт-Петербург, 192249";
                        order.delivery = new PickPointDelivery(order.address);
                        order.delivery.DeliverGoods();
                        break;
                    }
                case "Доставка в магазин":
                    {
                        Order<ShopDelivery, string> order = new Order<ShopDelivery, string>();
                        order.address = "Народная ул., 4, Санкт-Петербург магазин \"PickPoint\"";
                        order.delivery = new ShopDelivery(order.address);
                        order.delivery.DeliverGoods();
                        break;
                    }
                default:
                    break;
            }           

            Console.ReadKey();
        }
    }
}
