using BillingSystem.Controller;
using BillingSystem.Model;
using BillingSystem.View;

BillingSystemApp myBillingSys = new();
WaterConsumption waterConsumption = new WaterConsumption();
MainMenu.Show(myBillingSys, waterConsumption);
