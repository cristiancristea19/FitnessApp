import axios from "axios";
import { REGISTER_URL } from "../Utils/UrlConstants";

export default async (username, gender, height, weight, email, password) => {

    try {
        const reponse = await axios.post(REGISTER_URL, {
            user: {
                username: username,
                email: email,
                gender: gender,
                height: height,
                weight: weight,
                password: password,
                role: {
                    roleType: 1
                }
            }
        })
        return reponse.data
    } catch (error) {
        return {
            isError: true
        }
    }
}