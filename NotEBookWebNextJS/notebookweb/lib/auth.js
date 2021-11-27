import axios from 'axios'

export const loginUser = async (email, password) => {
    const response = await axios.post('/api/login', {email, password});

    console.log(response.data);
}