using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassSystem
{
    class Product<TProduct>
    {
        public TProduct product;
        
        public Product(TProduct product)
        {
            this.product = product;  
        }
        /// <summary>
        /// Выводит на экран содержимое поля "product"
        /// </summary>
        static public void PrintProduct(string[] product, int key)
        {
            int i = 0; 
            int j = 0;              
            Console.Clear();
            if (key >= 0)
            {
                Console.WriteLine("+" + new string('-', 44) + "+");
                Console.Write($"|\t   Раздел \"{Program.productType[key]}\"");
                Console.SetCursorPosition(45, 1);
                Console.WriteLine("|");
                j = 2;
            }          

            Console.WriteLine("+" + new string('-', 44) + "+");
            foreach (var item in product)
            {
                Console.Write($"| {++i} - {item}");
                Console.SetCursorPosition(45, j + i);
                Console.WriteLine("|");
            }
            Console.WriteLine("+" + new string('-', 44) + "+");
        }                        
        
        /// <summary>   
        /// Осуществляет выбор товара по его номеру...
        /// P.S: Множественный выбор не реализовывал, мне лень... 
        /// </summary>         
        public string ChooseProduct(string[] product, out int productNumber)
        {            
            string productName;
            Console.Write("Для заказа, выберите номер товара... ");
            
            bool flag;
            while (true)
            {
                flag = int.TryParse(Console.ReadLine(), out productNumber);
                if (--productNumber >= 0 && productNumber < product.Length && flag)
                {                    
                    productName = product[productNumber];
                    break;
                }
                else Console.Write("Не верный ввод, попробуйте еще... ");
            }
             
            return productName;  
        }
    }
}
