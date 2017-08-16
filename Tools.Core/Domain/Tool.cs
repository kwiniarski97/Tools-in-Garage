using System;

namespace Tools.Core.Domain
{
    /// <summary>
    /// Domain model of Tool object
    /// </summary>
    public class Tool
    {
        public Guid Id { get; protected set; }

        public string Model { get; protected set; }

        public string Brand { get; protected set; }

        public string Type { get; protected set; }

        public uint Box { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Guid id of item</param>
        /// <param name="model">Model of a tool ie.T4021 </param>
        /// <param name="brand">Brand ie. Bosch </param>
        /// <param name="type">Type of item ie. Screwdriver</param>
        public Tool(Guid id, string model, string brand, string type, uint box)
        {
            Id = id;
            SetModel(model);
            SetBrand(brand);
            SetType(type);
            //todo mozesz dodaj jakas maksymalna liczbe szafek czy inne
            Box = box;
        }

        //added because of conventions
        protected Tool()
        {
        }


        /// <summary>
        /// Set model method with validation
        /// </summary>
        /// <param name="model">Name of tool</param>
        /// <exception cref="Exception"></exception>
        //TODO moze dodaj jakas walidacje 
        private void SetModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new Exception("Model cannot be empty");
            }
            if (Model == model)
            {
                return;
            }

            Model = model;
        }

        /// <summary>
        /// Set Brand method with validation
        /// </summary>
        /// <param name="brand"></param>
        /// <exception cref="Exception"></exception>
        private void SetBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new Exception("Brand cannot be empty");
            }
            if (Brand == brand)
            {
                return;
            }

            Brand = brand;
        }

        private void SetType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new Exception("Type cannot be empty");
            }
            if (Type == type)
            {
                return;
            }
            //todo debug here
            var typeEnum = Enum.GetName(typeof(ToolTypesEnum), type);

            if (typeEnum == null)
            {
                throw new Exception($"Theres no tool of type: {type}");
            }
            Type = type;
        }
    }
}