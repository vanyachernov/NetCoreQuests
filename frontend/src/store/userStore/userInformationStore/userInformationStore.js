import { create } from "zustand";
import axios from "axios";

export const useUserInformationStore = create((set) => ({
    userData: {
        
    },
    
    fetchUserData: async () => {
        try {
            
        } catch (error) {
            
        }
    },
    setUserData: (newUserData) => {
        set((state) => ({
            userData: {
                ...state.userData,
                ...newUserData
            }
        }))
    },
}))