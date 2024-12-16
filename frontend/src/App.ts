import { defineComponent, onMounted, ref } from "vue";
import { apiService } from "./services/apiService";
import { Product } from "./types/Product";

export default defineComponent({
    name: "HelloWorld",
    setup() {
        // Tipos explícitos para los datos
        const data = ref<Product[]>([]);
        const headers = ref([
            { text: "ID", value: "id" },
            { text: "Name", value: "name" },
            { text: "Price", value: "price" },
          ]);
        const filter = ref<string>("");
        const msg = 'Productos'
        // Cargar datos desde el servicio
        const loadData = async (): Promise<void> => {
            try {
                const products = await apiService.getProducts();
                data.value = products;
            } catch (error) {
                console.error("Error loading data:", error);
            }
        };

        const applyFilter = async (): Promise<void> => {
            try {
                const products = await apiService.getProducts();
                data.value = products.filter((product: Product) =>
                    Object.values(product)
                        .join(" ")
                        .toLowerCase()
                        .includes(filter.value.toLowerCase())
                );
            } catch (error) {
                console.error("Error applying filter:", error);
            }
        };

        const clearFilter = () => {
            filter.value = ""; // Limpia el input
            loadData(); // Recarga los datos originales
          };

        onMounted(() => {
            loadData();
        });

        return {
            data,
            headers,
            filter,
            loadData,
            applyFilter, clearFilter
        };
    },
});
