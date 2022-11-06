import axios from "axios";
import { DELETE_WORKOUT_RECORD_URL } from "../Utils/UrlConstants";

export default async (workoutId) => {
    try {
        const response = await axios.delete(`${DELETE_WORKOUT_RECORD_URL}${workoutId}`)
        return response.data
    } catch (error) {
        return {
            isError: true
        }
    }
}