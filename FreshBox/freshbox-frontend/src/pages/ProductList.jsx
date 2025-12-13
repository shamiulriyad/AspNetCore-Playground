import React, { useState, useEffect } from 'react';
import ProductCard from '../components/ProductCard';
import '../App.css';

const ProductList = () => {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [category, setCategory] = useState('all');

  // Mock products data
  const mockProducts = [
    {
      id: 1,
      name: 'Fresh Tomatoes',
      description: 'Organic red tomatoes, freshly harvested',
      price: 2.99,
      imageUrl: 'https://via.placeholder.com/300x200?text=Tomatoes',
      unit: 'kg',
      rating: 4.5,
      stockQuantity: 50,
      isAvailable: true,
      category: 'vegetables'
    },
    {
      id: 2,
      name: 'Green Apples',
      description: 'Crisp and juicy green apples',
      price: 3.49,
      imageUrl: 'https://via.placeholder.com/300x200?text=Apples',
      unit: 'kg',
      rating: 4.7,
      stockQuantity: 30,
      isAvailable: true,
      category: 'fruits'
    },
    {
      id: 3,
      name: 'Fresh Spinach',
      description: 'Organic spinach leaves',
      price: 1.99,
      imageUrl: 'https://via.placeholder.com/300x200?text=Spinach',
      unit: 'bunch',
      rating: 4.2,
      stockQuantity: 20,
      isAvailable: true,
      category: 'vegetables'
    },
    {
      id: 4,
      name: 'Bananas',
      description: 'Ripe yellow bananas',
      price: 1.49,
      imageUrl: 'https://via.placeholder.com/300x200?text=Bananas',
      unit: 'dozen',
      rating: 4.0,
      stockQuantity: 0,
      isAvailable: false,
      category: 'fruits'
    },
    {
      id: 5,
      name: 'Carrots',
      description: 'Fresh orange carrots',
      price: 1.79,
      imageUrl: 'https://via.placeholder.com/300x200?text=Carrots',
      unit: 'kg',
      rating: 4.3,
      stockQuantity: 40,
      isAvailable: true,
      category: 'vegetables'
    },
    {
      id: 6,
      name: 'Strawberries',
      description: 'Sweet red strawberries',
      price: 4.99,
      imageUrl: 'https://via.placeholder.com/300x200?text=Strawberries',
      unit: 'box',
      rating: 4.8,
      stockQuantity: 15,
      isAvailable: true,
      category: 'fruits'
    }
  ];

  useEffect(() => {
    // Simulate API call
    setTimeout(() => {
      setProducts(mockProducts);
      setLoading(false);
    }, 500);
  }, []);

  // Filter products by category
  const filteredProducts = category === 'all' 
    ? products 
    : products.filter(product => product.category === category);

  if (loading) {
    return (
      <div className="loading">
        <div className="spinner"></div>
        <p>Loading products...</p>
      </div>
    );
  }

  return (
    <div className="product-list-page">
      <div className="page-header">
        <h1>Our Products</h1>
        <p>Fresh from the farm to your table</p>
      </div>

      {/* Category Filter */}
      <div className="category-filter">
        <button 
          className={`filter-btn ${category === 'all' ? 'active' : ''}`}
          onClick={() => setCategory('all')}
        >
          All Products
        </button>
        <button 
          className={`filter-btn ${category === 'vegetables' ? 'active' : ''}`}
          onClick={() => setCategory('vegetables')}
        >
          Vegetables
        </button>
        <button 
          className={`filter-btn ${category === 'fruits' ? 'active' : ''}`}
          onClick={() => setCategory('fruits')}
        >
          Fruits
        </button>
        <button 
          className={`filter-btn ${category === 'herbs' ? 'active' : ''}`}
          onClick={() => setCategory('herbs')}
        >
          Herbs
        </button>
      </div>

      {/* Products Grid */}
      <div className="products-grid">
        {filteredProducts.length > 0 ? (
          filteredProducts.map(product => (
            <ProductCard key={product.id} product={product} />
          ))
        ) : (
          <div className="no-products">
            <p>No products found in this category.</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default ProductList;