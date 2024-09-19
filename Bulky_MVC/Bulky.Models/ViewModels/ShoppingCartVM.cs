using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionFinds.Models.ViewModels { //we are using veiwModels to pass the data between model and views
	public class ShoppingCartVM {
		public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public OrderHeader OrderHeader { get; set; }
     
    }
}
