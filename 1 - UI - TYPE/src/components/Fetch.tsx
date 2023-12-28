import Host, { Port } from "../../../1 - UI - VUE/src/Conf";

export async function FetchGet(route: string) {
    try {
        const response = await fetch(`${Host}${Port}${route}`);
        return await response.json();
    } catch (error) {
        console.error('Error fetching data:', error);
        throw error;
    }
}
