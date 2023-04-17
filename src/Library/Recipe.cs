//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }


        public double GetProductionCost()
        {
            int ins_cost = 0;
            int equip_cost = 0;
            foreach (Step step in this.steps)
            {
                ins_cost = ins_cost + step.Input.GetUnitCost;  // ins_cost = ins_cost + step.Quantity es lo mismo?  // Primera parte
                equip_cost = equip_cost + step.Equipment.GetHourlyCost * step.GetTime; // Segunda parte
            }
            return ins_cost + equip_cost;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }

            Console.WriteLine();

            Console.WriteLine($"El costo unitario es {GetProductionCost()}"); // Tercera parte
        }
    }
}