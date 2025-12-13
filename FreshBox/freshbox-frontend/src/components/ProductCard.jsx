import React from 'react';
import { Link } from 'react-router-dom';

const ProductCard = ({ product }) => {
  return (
    <div className="product-card">
      <img 
        src={product.imageUrl || '/placeholder.jpg'} 
        alt={product.name}
        className="product-image"
      />
      <div className="product-info">
        <h3 className="product-name">{product.name}</h3>
        <p className="product-description">{product.description}</p>
        <div className="product-details">
          <span className="product-price">${product.price}</span>
          <span className="product-unit">{product.unit}</span>
        </div>
        <div className="product-rating">
          ⭐ {product.rating || 'No ratings'}
        </div>
        <Link to={`/products/${product.id}`} className="btn btn-view">
          View Details
        </Link>
        <button className="btn btn-add-to-cart">
          Add to Cart
        </button>
      </div>
    </div>
  );
};

export default ProductCard;