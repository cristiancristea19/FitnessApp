import axios from "axios";
import { FILTER_BY_ACTIVITY_TYPE } from "../Utils/UrlConstants";

export default async (userId, activityType) => {
    try {
        const reponse = await axios.get(`${FILTER_BY_ACTIVITY_TYPE}${userId}/${activityType}`)
        return reponse.data
    } catch (error) {
        return {
            isError: true
        }
    }
}