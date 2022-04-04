using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        #region Attribute
        public object listViewSource;
        #endregion

        #region Properties
        public object ListViewSourceTxt
        {
            get { return this.listViewSource; }
            set { SetValue(ref this.listViewSource, value); }
        }
        #endregion

        #region Methods
        public async Task LoadData()
        {
            this.ListViewSourceTxt = await App.Database.GetProdModel();
        }
        #endregion

        #region Constructor
        public ListViewModel()
        {
            LoadData();
        }
        #endregion
    }
}
