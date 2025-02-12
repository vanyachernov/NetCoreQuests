import { create } from "zustand";
import { urls, BASE_URL } from "../../../constants/urls.js";
import axios from "axios";

export const useQuestsStore = create((set) => ({
    quests: [],
    currentQuest: {},
    isLoading: false,
    fetchQuests: async () => {
        try {
            const response = await axios.get(`${urls.QUESTS.GET}`)
            set({quests: response.data, isLoading: false})
        } catch (error) {
            console.error("Failed to fetch quests", error);

        }
    },
    fetchQuestById: async (questId) => {
        try {
            const response = await axios.get(`${BASE_URL}/Tests/${questId}`)
            set({currentQuest: response.data})
        } catch (error) {
            console.error("Failed to fetch quest by ID", error);
        }
    }
}))