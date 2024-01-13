import type { Config } from 'tailwindcss'
const config: Config = {
  content: [
      "./index.html", 
    "./src/**/*.{js,ts,jsx,tsx}"
  ],
  theme: {
    extend: {},
  },
  darkMode: "class",
  plugins: [
    require('flowbite/plugin'),
  ],
}

export default config
