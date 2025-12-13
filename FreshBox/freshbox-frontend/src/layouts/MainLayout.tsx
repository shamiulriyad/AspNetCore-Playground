import React, { ReactNode } from 'react';
import { Link } from 'react-router-dom';

interface MainLayoutProps {
  children: ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
  return (
    <div className="main-layout">
      {/* Header will be added by App.tsx */}
      <main className="main-content">
        {children}
      </main>
      
      <footer className="footer">
        <div className="footer-content">
          <div className="footer-section">
            <h3>FreshBox</h3>
            <p>Fresh produce delivered to your door</p>
          </div>
          
          <div className="footer-section">
            <h4>Quick Links</h4>
            <ul>
              <li><Link to="/">Home</Link></li>
              <li><Link to="/products">Products</Link></li>
              <li><Link to="/about">About Us</Link></li>
              <li><Link to="/contact">Contact</Link></li>
            </ul>
          </div>
          
          <div className="footer-section">
            <h4>Contact Us</h4>
            <p>Email: support@freshbox.com</p>
            <p>Phone: +880 1234 567890</p>
          </div>
          
          <div className="footer-section">
            <h4>Follow Us</h4>
            <div className="social-links">
              <a href="#">Facebook</a>
              <a href="#">Instagram</a>
              <a href="#">Twitter</a>
            </div>
          </div>
        </div>
        
        <div className="footer-bottom">
          <p>&copy; {new Date().getFullYear()} FreshBox. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
};

export default MainLayout;