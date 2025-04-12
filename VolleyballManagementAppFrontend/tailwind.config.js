/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  theme: {
    extend: {
      colors: {
        primary: "#7D1A1A",
        gold: "#BD973A",
        beige: "#F3E5C6",
        soft: {
          white: "#FFFFFF",
          dark: "#444C45"
        }
      }
    },
  },
  plugins: [],
}