
<script lang="tsx">

export async function GetFetch(url: string) {
    try {
        const response = await fetch(`https://localhost:7113/${url}`);
        return await response.json();
    } catch (error) {
        console.error('Error fetching data:', error);
        throw error;
    }
};

export async function PostFetch(url:string, data: any) {
    fetch(`https://localhost:7113/${url}`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  })
    .then((response) => {
      if (response.status === 200) {
        return response.json();
      } else if (response.status === 401) {
        throw new Error('Unauthorized');
      } else {
        throw new Error('failed');
      }
    })
}


</script>