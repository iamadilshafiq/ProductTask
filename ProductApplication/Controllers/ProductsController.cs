using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductApplication.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/
        
        public ActionResult Index()
        {
            Models.SaleModel mySale = new Models.SaleModel();
            //Hard coded array of 10 Products
            mySale.Products = new[] {
                new Models.Product()
                {
                    Id = 1,
                    Name = "Back Pack",
                    Description = "An elegent back pack!",
                    ImageUrl = "../../Content/Images/backPack.png",
                    Price = 1500,
                },
                new Models.Product()
                {
                    Id = 2,
                    Name = "Camera",
                    Description = "Your companion on the go!",
                    ImageUrl = "../../Content/Images/camera.png",
                    Price = 40000,
                },
                new Models.Product()
                {
                    Id = 3,
                    Name = "Data Cable",
                    Description = "Transfer data at lightning speed!",
                    ImageUrl = "../../Content/Images/dataCable.png",
                    Price = 200,
                },
                new Models.Product()
                {
                    Id = 4,
                    Name = "Head Phone",
                    Description = "Listen to the world around you!",
                    ImageUrl = "../../Content/Images/headphone.png",
                    Price = 1000,
                },
                new Models.Product()
                {
                    Id = 5,
                    Name = "Helmet",
                    Description = "Protect what matters the most!",
                    ImageUrl = "../../Content/Images/helmet.png",
                    Price = 5000,
                },
                new Models.Product()
                {
                    Id = 6,
                    Name = "Laptop",
                    Description = "Play games like a pro!",
                    ImageUrl = "../../Content/Images/laptop.png",
                    Price = 90000,
                },
                new Models.Product()
                {
                    Id = 7,
                    Name = "Phone",
                    Description = "Elegent touch, fast processing!",
                    ImageUrl = "../../Content/Images/phone.png",
                    Price = 60000,
                },
                new Models.Product()
                {
                    Id = 8,
                    Name = "Power Bank",
                    Description = "Charge devices on the go!",
                    ImageUrl = "../../Content/Images/powerbank.png",
                    Price = 1500,
                },
                new Models.Product()
                {
                    Id = 9,
                    Name = "Smart Watch",
                    Description = "Offcourse not as smart as you are for buying it!",
                    ImageUrl = "../../Content/Images/smartWatch.png",
                    Price = 4500,
                },
                new Models.Product()
                {
                    Id = 10,
                    Name = "Watch",
                    Description = "Time is money folks!",
                    ImageUrl = "../../Content/Images/watch.png",
                    Price = 3000,
                },
            };

            //Check if data has been posted
            if (Request["productID"] != null)
            {
                //Save Posted Data to SaleItem Class
                Models.SaleItem Item = new Models.SaleItem();
                Item.ProductItem = new Models.Product()
                {
                    Id = int.Parse(Request["productId"]),
                    Name = Request["productName"],
                    Description = Request["productDescription"],
                    ImageUrl = Request["productUrl"],
                    Price = decimal.Parse(Request["productPrice"]),
                };
                Item.Quantity = 1;

                //Retrieve Session Variables if any
                mySale.SaleItems = Session["saleItems"] as List<Models.SaleItem>;
                if (Session["totalPayment"] != null)
                {
                    mySale.totalPayment = decimal.Parse(Session["totalPayment"].ToString());
                }

                //Check if Sale Item list is empty
                if (mySale.SaleItems != null)
                {
                    //Check if SaleITem Already Exists in SaleItem List
                    var savedSaleItem = mySale.SaleItems.FirstOrDefault(x => x.ProductItem.Id == Item.ProductItem.Id);
                    if (savedSaleItem != null)
                    {
                        //Update the quantity of existing item and total payment
                        savedSaleItem.Quantity += 1;
                        mySale.totalPayment = decimal.Parse(Session["totalPayment"].ToString());
                        mySale.totalPayment += savedSaleItem.ProductItem.Price;
                    }
                    else
                    {
                        //Add new sale item to SaleModel and 
                        mySale.SaleItems.Add(Item);
                        mySale.totalPayment += Item.ProductItem.Price;
                    } 
                }
                else
                {
                    //Initialize SaleModel SaleItem List for the First Time and Add SaleItem
                    mySale.SaleItems = new List<Models.SaleItem>();
                    mySale.SaleItems.Add(Item);   
                    mySale.totalPayment += Item.ProductItem.Price;
                }    
            }
            //Save objects to session
            Session["saleItems"] = mySale.SaleItems;
            Session["totalPayment"] = mySale.totalPayment;
            
            //Pass the SaleModel to view
            return View(mySale);
        }
    }
}
