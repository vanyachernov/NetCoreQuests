import { create } from "zustand";
import axios from "axios";

export const useQuestsStore = create((set) => ({
    quests: [],
    selectedQuest: null,
    isLoading: false,
    fetchQuests: async () => {
        try {
            
        } catch (error) {
            
        }
    },
    getQuestById: (id) => {
        
    },
}))