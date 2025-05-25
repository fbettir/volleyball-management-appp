/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  theme: {
    extend: {
      colors: {
        primary: "#7D1A1A",
        textprimary: '#000000',
        textsecondary: '#7D1A1A',
        textdark: '#444C45', 
        white: "#FFFFFF",     
        soft: {
          white: "#FFFFFF",
          dark: "#444C45"
        }
      },
      fontFamily: {
        sans: ['Montserrat', 'sans-serif'],
      }
    },
  },
  //plugins: [require('@tailwindcss/line-clamp')],
}