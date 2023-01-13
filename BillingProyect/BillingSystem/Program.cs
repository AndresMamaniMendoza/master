using BillingSystem.Controller;
using BillingSystem.Model;
using BillingSystem.View;
using System;

Console.WriteLine("asd");
BillingSystemApp myBillingSys = new();
WaterConsumption waterConsumption = new WaterConsumption();
waterConsumption.Amount = 100;
waterConsumption.DateTime = DateTime.Now;
Associate Mich = new Associate();
Mich.Id = 1045;
Mich.Name = "Michelle";
Mich.Lastname = "Cadavid";
Mich.Direction = "dir";
myBillingSys.associateList.Add(Mich);
myBillingSys.RegisterWaterConsumptionReading(Mich.Id, waterConsumption);

Associate Andres = new Associate();
Andres.Id = 1111;
Andres.Name = "Andres";
Andres.Lastname = "M";
Andres.Direction = "Bolivia";
myBillingSys.associateList.Add(Andres);

MainMenu.Show(myBillingSys);


//List<KeyValuePair<Debts, Payment>> historyList = new();

//Debts debts = new Debts();
//Payment payment = new Payment();

//historyList.Add(new KeyValuePair<Debts, Payment>(debts, payment));

//for (int i = 0; i < historyList.Count; i++)
//{
//    Console.WriteLine(historyList[i].Key);
//}