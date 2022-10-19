import axios from "axios";
import { GET_WORKOUT_RECORDS_URL } from "../Utils/UrlConstants";

export default async (userId) => {
    try {
        const reponse = await axios.get(`${GET_WORKOUT_RECORDS_URL}${userId}`)
        return reponse.data
    } catch (error) {
        return {
            isError: true
        }
    }
}