using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace App_GSB.ViewModels
{

    public class MedicamentViewModel : ViewModelBase
    {
        private readonly HttpClient _client;
        private readonly INavigationService _navigationService;

        public MedicamentViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _client = new HttpClient();
            _navigationService = navigationService;
            Title = "Médicament";
        }

        public String MED_DEPOTLEGAL
        {
            get { return _MED_DEPOTLEGAL; }
            set { SetProperty(ref _MED_DEPOTLEGAL, value); }
        }
        private String _MED_DEPOTLEGAL;
        public String MED_NOMCOMMERCIAL
        {
            get { return _MED_NOMCOMMERCIAL; }
            set { SetProperty(ref _MED_NOMCOMMERCIAL, value); }
        }
        private String _MED_NOMCOMMERCIAL;
        public String FAM_CODE
        {
            get { return _FAM_CODE; }
            set { SetProperty(ref _FAM_CODE, value); }
        }
        private String _FAM_CODE;
        public String MED_COMPOSITION
        {
            get { return _MED_COMPOSITION; }
            set { SetProperty(ref _MED_COMPOSITION, value); }
        }
        private String _MED_COMPOSITION;
        public String MED_EFFETS
        {
            get { return _MED_EFFETS; }
            set { SetProperty(ref _MED_EFFETS, value); }
        }
        private String _MED_EFFETS;
        
        public String MED_CONTREINDIC
        {
            get { return _MED_CONTREINDIC; }
            set { SetProperty(ref _MED_CONTREINDIC, value); }
        }
        private String _MED_CONTREINDIC;



        public String Answer
        {
            get { return _answer; }
            set { SetProperty(ref _answer, value); }
        }
        private String _answer;
        public int Numero
        {
            get { return _numero; }
            set { SetProperty(ref _numero, value); }
        }
        private int _numero;

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {

            Numero = 0;
            getCompteRendu();

            base.OnNavigatedTo(parameters);

        }

        public DelegateCommand PLus
        {
            get { return _pLus ?? (_pLus = new DelegateCommand(RunPLus, CanRunPLus)); }
        }
        private DelegateCommand _pLus;
        public async void RunPLus()
        {
            Numero++;
            getCompteRendu();
        }

        public virtual bool CanRunPLus()
        {
            return true;
        }

        public DelegateCommand Moins
        {
            get { return _moins ?? (_moins = new DelegateCommand(RunMoins, CanRunMoins)); }
        }
        private DelegateCommand _moins;
        public async void RunMoins()
        {
            if (Numero >= 1)
            {
                Numero--;
                getCompteRendu();
            }
        }

        public virtual bool CanRunMoins()
        {
            return true;
        }


        public async void getCompteRendu()
        {

            try
            {
                Uri uri = new Uri("https://api.gsb-france.fr/MedicamentbyDEPOTLEGAL.php");
                Console.WriteLine("{0} URI", uri);

                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var answer = await response.Content.ReadAsStringAsync();
                    dynamic dynJson = JsonConvert.DeserializeObject(answer);
                    MED_DEPOTLEGAL = dynJson[Numero].MED_DEPOTLEGAL;

                }

                Uri uriMed = new Uri("https://api.gsb-france.fr/MedicamentbyDEPOTLEGAL.php?depotLegal=" + MED_DEPOTLEGAL);
                Console.WriteLine("{0} URI", uriMed);

                HttpResponseMessage responseMed = await _client.GetAsync(uriMed);
                if (responseMed.IsSuccessStatusCode)
                {
                    var answerMed = await responseMed.Content.ReadAsStringAsync();
                    dynamic dynJsonMed = JsonConvert.DeserializeObject(answerMed);
                    Console.WriteLine("{0} URI", dynJsonMed);

                    MED_DEPOTLEGAL = dynJsonMed.MED_DEPOTLEGAL;
                    MED_NOMCOMMERCIAL = dynJsonMed.MED_NOMCOMMERCIAL;
                    FAM_CODE = dynJsonMed.FAM_CODE;
                    MED_COMPOSITION = dynJsonMed.MED_COMPOSITION;
                    MED_EFFETS = dynJsonMed.MED_EFFETS;
                    MED_CONTREINDIC = dynJsonMed.MED_CONTREINDIC;                    

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR", e);
            }
        }
    }
}
