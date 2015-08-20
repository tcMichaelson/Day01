using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartWithArrayList {
    class ShoppingCart {
        public ShoppingCart() {
            CartList = new ArrayList();
        }

        private ArrayList CartList;

        public int AddItem(ShoppingCartItem item) {
            CartList.Add(item);
            return CartList.IndexOf(item);
        }

        public bool RemoveItem(int Id) {
            if ((CartList.Capacity - 1) <= Id) {
                return false;
            }
            CartList.RemoveAt(Id);
            return true;
        }

        public int ListItems() {
            int i = 0;
            foreach (var item in CartList) {
                Console.WriteLine(((ShoppingCartItem)item).Id);
                Console.WriteLine(((ShoppingCartItem)item).Name);
                Console.WriteLine(((ShoppingCartItem)item).Price);
                i++;
            }
            return i;
        }
    }

    class ShoppingCartItem {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Program {
        static void Main(string[] args) {
            var cart1 = new ShoppingCart();
            var banana = new ShoppingCartItem() {
                Name = "Bananas",
                Price = 2.25m
            };
            var beanie = new ShoppingCartItem() {
                Name = "Beanie Baby",
                Price = 12.34m
            };
            var ps3 = new ShoppingCartItem() {
                Name = "PS3",
                Price = 150.99m
            };
            banana.Id = cart1.AddItem(banana);
            beanie.Id = cart1.AddItem(beanie);
            ps3.Id = cart1.AddItem(ps3);
            cart1.RemoveItem(3);
            cart1.ListItems();
            Debug.Assert(cart1.AddItem(new ShoppingCartItem { Name = "dlk", Price = 3.2m }) == 3, "This is not the 3rd index");
            Debug.Assert(cart1.RemoveItem(1) == true, "There is no cart1 item 1");
            Debug.Assert(cart1.ListItems() == 3, "There aren't 3 items here");
            Console.ReadLine();
        }
    }
}
