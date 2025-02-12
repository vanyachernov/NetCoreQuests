import { create } from "zustand";
import { persist } from "zustand/middleware";

export const useUserInformationStore = create(
    persist(
        (set) => ({
            userData: {},
            isValid: false,
            loadUserData: (newUserData) => {
                const currentTime = Date.now()
                localStorage.setItem("user-time", currentTime)
                set((state) => ({
                    userData: {
                        ...state.userData,
                        ...newUserData
                    },
                    isValid: true
                }))
            },
            setUserData: (newUserData) => {
                set((state) => ({
                    userData: {
                        ...state.userData,
                        ...newUserData
                    }
                }))
            },
            checkExpiration: () => {
                const loadTime = localStorage.getItem('user-time')
                const currentTime = Date.now()
                const expirationTime = 7 * 24 * 60 * 60 * 1000
                const timeDifference = currentTime - Number(loadTime)

                if (timeDifference > expirationTime) {
                    localStorage.removeItem('user-time')
                    localStorage.removeItem('user-data')
                    set({userData: {}, isValid: false})
                }
            },
        }),
        {
            name: "user-data",
            getStorage: () => localStorage,
        }
    )
)