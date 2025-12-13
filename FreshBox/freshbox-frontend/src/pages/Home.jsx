import React from 'react';
import { Link } from 'react-router-dom';
import '../App.css';

const Home = () => {
  return (
    <div className="home">
      {/* Hero Section */}
      <section className="hero">
        <div className="hero-content">
          <h1>FreshBox - Fresh Produce Delivered</h1>
          <p>Get farm-fresh vegetables and fruits delivered to your doorstep within hours</p>
          <Link to="/products" className="btn btn-primary">
            Shop Fresh Now
          </Link>
        </div>
      </section>

      {/* Features Section */}
      <section className="features">
        <h2>Why Choose FreshBox?</h2>
        <div className="features-grid">
          <div className="feature-card">
            <div className="feature-icon">🚚</div>
            <h3>Fast Delivery</h3>
            <p>Get your order delivered within 2-4 hours</p>
          </div>
          <div className="feature-card">
            <div className="feature-icon">🥦</div>
            <h3>Farm Fresh</h3>
            <p>Direct from local farms to your kitchen</p>
          </div>
          <div className="feature-card">
            <div className="feature-icon">💰</div>
            <h3>Best Prices</h3>
            <p>Competitive prices without middlemen</p>
          </div>
          <div className="feature-card">
            <div className="feature-icon">✅</div>
            <h3>Quality Guarantee</h3>
            <p>100% quality satisfaction or money back</p>
          </div>
        </div>
      </section>

      {/* Categories Section */}
      <section className="categories">
        <h2>Shop by Category</h2>
        <div className="categories-grid">
          <Link to="/products?category=vegetables" className="category-card">
            <div className="category-icon">🥬</div>
            <h3>Vegetables</h3>
          </Link>
          <Link to="/products?category=fruits" className="category-card">
            <div className="category-icon">🍎</div>
            <h3>Fruits</h3>
          </Link>
          <Link to="/products?category=herbs" className="category-card">
            <div className="category-icon">🌿</div>
            <h3>Herbs</h3>
          </Link>
          <Link to="/products?category=organic" className="category-card">
            <div className="category-icon">🌱</div>
            <h3>Organic</h3>
          </Link>
        </div>
      </section>
    </div>
  );
};

export default Home;