// src/services/apiService.ts
import axios, { AxiosInstance } from "axios";
import { environment } from "../environments/environment";
import { Product } from "../types/Product";

class ApiService {
    private client: AxiosInstance;

    constructor() {
        this.client = axios.create({
            baseURL: environment.apiBaseUrl,
        });
    }

    async getProducts(): Promise<Product[]> {
        try {
            const response = await this.client.get<Product[]>("products");
            return response.data;
        } catch (error: any) {
            console.error("Error fetching products:", error.message);
            throw error;
        }
    }

    async addProduct(product: Product): Promise<Product> {
        try {
            const response = await this.client.post<Product>("products", product);
            return response.data;
        } catch (error: any) {
            console.error("Error adding product:", error.message);
            throw error;
        }
    }

    async deleteProduct(productId: number): Promise<void> {
        try {
            await this.client.delete(`products/${productId}`);
        } catch (error: any) {
            console.error("Error deleting product:", error.message);
            throw error;
        }
    }

    async updateProduct(product: Product): Promise<Product> {
        try {
            const response = await this.client.put<Product>(`products/${product.id}`, product);
            return response.data;
        } catch (error: any) {
            console.error("Error updating product:", error.message);
            throw error;
        }
    }
}

export const apiService = new ApiService();
