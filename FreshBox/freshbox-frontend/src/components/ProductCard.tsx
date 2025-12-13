import React from 'react';
import { Link } from 'react-router-dom';

interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
  unit: string;
  rating?: number;
  stockQuantity: number;
  isAvailable: boolean;
}

interface ProductCardProps {
  product: Product;
}

const ProductCard: React.FC<ProductCardProps> = ({ product }) => {
  return (
    <div className="product-card">
      <img 
        src={product.imageUrl || '/placeholder.jpg'} 
        alt={product.name}
        className="product-image"
      />
      <div className="product-info">
        <h3 className="product-name">{product.name}</h3>
        <p className="product-description">
          {product.description.length > 100 
            ? `${product.description.substring(0, 100)}...` 
            : product.description}
        </p>
        <div className="product-details">
          <span className="product-price">${product.price.toFixed(2)}</span>
          <span className="product-unit">per {product.unit}</span>
          <span className={`stock-status ${product.isAvailable ? 'in-stock' : 'out-of-stock'}`}>
            {product.isAvailable ? 'In Stock' : 'Out of Stock'}
          </span>
        </div>
        <div className="product-rating">
          ⭐ {product.rating ? product.rating.toFixed(1) : 'No ratings yet'}
        </div>
        <div className="product-actions">
          <Link to={`/products/${product.id}`} className="btn btn-view">
            View Details
          </Link>
          <button 
            className="btn btn-add-to-cart"
            disabled={!product.isAvailable}
          >
            {product.isAvailable ? 'Add to Cart' : 'Out of Stock'}
          </button>
        </div>
      </div>
    </div>
  );
};

export default ProductCard;