import axios from "axios";
import { ADD_WORKOUT_RECORD_URL } from "../Utils/UrlConstants";

export default async (userId, distance, hours, minutes, seconds, calories, activityType) => {
    try {
        const response = await axios.post(ADD_WORKOUT_RECORD_URL, {
            workoutRecord: {
                userId: userId,
                distance: distance,
                duration: {
                    hours: hours,
                    minutes: minutes,
                    seconds: seconds
                },
                calories: calories,
                activity: {
                    activityType: activityType
                }
            }
        })
        return response.data
    } catch (error) {
        return {
            isError: true
        }
    }
}