using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MTGO_lite.Models.Manas.ManaColors
{
    [DebuggerDisplay("{ColorName}({Quantity})")]
    public abstract class ManaColor
    {
        protected int quantity;

        public int Quantity { get => quantity; }
        public abstract string ColorName { get; }
        public abstract Bitmap Icon { get; }

        public event EventHandler<int> ManaChanged;

        protected ManaColor(int quantity)
        {
            this.quantity = quantity;
        }

        public ManaColor(ManaColor manaColor)
        {
            this.quantity = manaColor.quantity;
        }

        public void Add(ManaColor mana)
        {
            this.quantity += mana.quantity;
            ManaChanged?.Invoke(this, quantity);
        }

        public void Remove(ManaColor mana)
        {
            this.quantity -= mana.quantity;
            ManaChanged?.Invoke(this, quantity);
        }

        public void Remove(int quantity)
        {
            this.quantity -= quantity;
            ManaChanged?.Invoke(this, quantity);
        }

        public override string ToString()
        {
            return $"{ColorName}: {Quantity}";
        }

        public static bool operator >(ManaColor a, ManaColor b)
        {
            return a.quantity > b.quantity;
        }
        
        public static bool operator <(ManaColor a, ManaColor b)
        {
            return a.quantity < b.quantity;
        }
            

    }
}
