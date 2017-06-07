using MyMoney.Service.BillingCycle.Test;

namespace MyMoney.ViewModel.MasterDetail
{
    public class MasterDetailContainerPageDetailViewModel: BaseViewModel
    {
        private double _sumCredits;

        public double SumCredits
        {
            get { return _sumCredits; }
            set { SetProperty(ref _sumCredits, value); }
        }

        private double _sumDebits;

        public double SumDebits
        {
            get { return _sumDebits; }
            set { SetProperty(ref _sumDebits, value); }
        }

        private double _valueConsolidated;

        public double ValueConsolidated
        {
            get { return _valueConsolidated; }
            set { SetProperty(ref _valueConsolidated, value); }
        }


        public MasterDetailContainerPageDetailViewModel()
        {
            var result = BillingCycleData.Summary();

            SumCredits = result.Item1.Value;
            SumDebits = result.Item2.Value;
            ValueConsolidated = result.Item3;
        }
    }
}
