import React, { createContext, useState, useContext, useEffect } from 'react';

// Create context
const AuthContext = createContext();

export const useAuth = () => {
  return useContext(AuthContext);
};

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);
  const [token, setToken] = useState(localStorage.getItem('token'));

  // Check if user is logged in on app start
  useEffect(() => {
    const checkAuth = async () => {
      const storedToken = localStorage.getItem('token');
      const storedUser = localStorage.getItem('user');
      
      if (storedToken && storedUser) {
        setToken(storedToken);
        setUser(JSON.parse(storedUser));
      }
      
      setLoading(false);
    };
    
    checkAuth();
  }, []);

  // Login function
  const login = async (email, password) => {
    try {
      // For now, mock login
      // TODO: Replace with actual API call
      const mockUser = {
        id: 1,
        name: 'Test User',
        email: email,
        role: 'customer'
      };
      
      const mockToken = 'mock-jwt-token';
      
      localStorage.setItem('token', mockToken);
      localStorage.setItem('user', JSON.stringify(mockUser));
      
      setToken(mockToken);
      setUser(mockUser);
      
      return { success: true, user: mockUser };
    } catch (error) {
      return { success: false, message: 'Login failed' };
    }
  };

  // Register function
  const register = async (userData) => {
    try {
      // TODO: Replace with actual API call
      const newUser = {
        id: Date.now(),
        ...userData,
        role: 'customer'
      };
      
      return { success: true, user: newUser };
    } catch (error) {
      return { success: false, message: 'Registration failed' };
    }
  };

  // Logout function
  const logout = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    setToken(null);
    setUser(null);
  };

  const value = {
    user,
    token,
    loading,
    login,
    register,
    logout,
    isAuthenticated: !!token
  };

  return (
    <AuthContext.Provider value={value}>
      {children}
    </AuthContext.Provider>
  );
};