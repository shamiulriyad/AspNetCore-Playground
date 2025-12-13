import axiosClient from './axiosClient';

export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
  unit: string;
  rating?: number;
  stockQuantity: number;
  isAvailable: boolean;
  categoryId?: number;
  farmerId?: number;
  createdAt?: string;
  updatedAt?: string;
}

export interface ProductResponse {
  data: Product[];
  total: number;
  page: number;
  pageSize: number;
}

export const productApi = {
  // Get all products
  getAll: (params?: any): Promise<ProductResponse> => {
    return axiosClient.get('/products', { params });
  },

  // Get product by ID
  getById: (id: number): Promise<Product> => {
    return axiosClient.get(`/products/${id}`);
  },

  // Create new product (admin/farmer only)
  create: (data: Partial<Product>): Promise<Product> => {
    return axiosClient.post('/products', data);
  },

  // Update product
  update: (id: number, data: Partial<Product>): Promise<Product> => {
    return axiosClient.put(`/products/${id}`, data);
  },

  // Delete product
  delete: (id: number): Promise<void> => {
    return axiosClient.delete(`/products/${id}`);
  },

  // Search products
  search: (query: string): Promise<ProductResponse> => {
    return axiosClient.get('/products/search', { params: { q: query } });
  },

  // Get products by category
  getByCategory: (categoryId: number): Promise<ProductResponse> => {
    return axiosClient.get(`/products/category/${categoryId}`);
  }
};