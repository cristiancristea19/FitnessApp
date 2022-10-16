import axios from "axios";
import { LOGIN_URL } from "../Utils/UrlConstants";
export default async (username, password) => {

    try {
        const reponse = await axios.post(LOGIN_URL, {
            user: {
                username: username,
                password: password
            }
        })
        return reponse.data
    } catch (error) {
        return {
            isError: true
        }
    }
}