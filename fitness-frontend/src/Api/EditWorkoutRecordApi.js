import axios from "axios";
import { EDIT_WORKOUT_RECORD_URL } from "../Utils/UrlConstants";

export default async (id, distance, hours, minutes, seconds, calories, activityType) => {
    try {
        const reponse = await axios.put(EDIT_WORKOUT_RECORD_URL, {
            workoutRecord: {
                id: id,
                distance: distance,
                duration: {
                    hours: hours,
                    minutes: minutes,
                    seconds: seconds
                },
                calories: calories,
                activityType: activityType
            }
        })
        return reponse.data
    } catch (error) {
        return {
            isError: true
        }
    }
}