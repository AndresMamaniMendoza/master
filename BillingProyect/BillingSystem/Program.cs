using BillingSystem.Controller;
using BillingSystem.Model;
using BillingSystem.View;

BillingSystemApp myBillingSys = new();
WaterConsumption waterConsumption = new WaterConsumption();
Associate Mich = new Associate();
Mich.Id= 1045;
Mich.Name = "Michelle";
Mich.Lastname = "Cadavid";
Mich.Direction = "dir";
myBillingSys.associateList.Add(Mich);
MainMenu.Show(myBillingSys, waterConsumption);
