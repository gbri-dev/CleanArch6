using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsEntity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productsEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productsEntity);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var productsEntity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productsEntity);
        }

        public async Task CreateAsync(ProductDTO productDto)
        {
            var productsEntity = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(productsEntity);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var productsEntity = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(productsEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var productsEntity = _mapper.Map<Product>(id);
            await _productRepository.RemoveAsync(productsEntity);
        }
    }
}
