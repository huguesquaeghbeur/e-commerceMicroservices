/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,js,jsx,ts,tsx}",
  ],
  theme: {
    fontSize: {
      xs: '0.5rem',
      base: '0.8rem',
    },
    extend: {
      transitionDuration: {
        customDuration: '.5s',
      },
      transitionTimingFunction: {
        customTiming: 'cubic-bezier(.25,.46,.45,.94)',
      },
    },
  plugins: [],
}}