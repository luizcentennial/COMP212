using Example21.Commands;
using Example21.Models;
using Example21.Services.Implementations;
using Example21.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Example21.ViewModels {
    public class MainWindowViewModel : BaseViewModel {
        private readonly ProductService _productService = new ProductService();

        private ObservableCollection<Product> _products;
        private Product _selectedProduct;
        private Product _newProduct;

        public ObservableCollection<Product> Products { 
            get => this._products; 
            set => this.SetAndNotify(ref this._products, value);
        }

        public Product SelectedProduct {
            get => this._selectedProduct;
            set => this.SetAndNotify(ref this._selectedProduct, value);
        }

        public Product NewProduct {
            get => this._newProduct;
            set => this.SetAndNotify(ref this._newProduct, value);
        }

        public ICommand CreateProductCommand { get; set; }

        public MainWindowViewModel() {
            this.Init();
        }

        private void Init() {
            this.LoadProducts();
            this.NewProduct = new Product();

            this.CreateProductCommand = new RelayCommand(
                action: (o) => CreateProduct()
            );
        }

        private void CreateProduct() {
            if (string.IsNullOrWhiteSpace(this.NewProduct.Name)
                || string.IsNullOrWhiteSpace(this.NewProduct.Description)
                || this.NewProduct.Price < 0.01)
                return;

            this._productService.Create(this.NewProduct);

            this.NewProduct = new Product();
            this.LoadProducts();        
        }

        private void LoadProducts() {
            var products = this._productService.GetAll();
            this.Products = new ObservableCollection<Product>(products);
        }
    }
}