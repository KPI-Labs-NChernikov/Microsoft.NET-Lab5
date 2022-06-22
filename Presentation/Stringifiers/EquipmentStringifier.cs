using Business.Managers;
using Data.Interfaces;
using Presentation.Interfaces;

namespace Presentation.Stringifiers
{
    public class EquipmentStringifier : IStringifier
    {
        private IEquipment _equipment;

        public IEquipment Equipment
        {
            get { return _equipment; }
            set => _equipment = value ?? throw new ArgumentNullException(nameof(value));
        }

        public RentalManager? Manager { get; set; }

        public EquipmentStringifier(IEquipment equipment)
        {
            _equipment = equipment ?? throw new ArgumentNullException(nameof(equipment));
        }

        public string Stringify()
        {
            var result = _equipment.ToString() ?? string.Empty;
            if (Manager != null)
                result += $"{Environment.NewLine}" +
                    $"Price per day: {Manager.GetRentalCost(_equipment, TimeSpan.FromDays(1)):F2} UAH";
            return result + Environment.NewLine;
        }
    }
}
