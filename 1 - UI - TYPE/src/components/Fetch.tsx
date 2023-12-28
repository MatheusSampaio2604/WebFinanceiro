import Host, { Port } from "../Conf";

export async function FetchGet(route: string) {
    try {
        const response = await fetch(`${Host}${Port}${route}`);
        return await response.json();
    } catch (error) {
        console.error('Error fetching data:', error);
        throw error;
    }
}
