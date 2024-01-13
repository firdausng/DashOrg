import {Router, RouterProvider} from "@tanstack/react-router";
import routeTree from "./route.tsx";


const router = new Router({ routeTree });
function App() {
    return <RouterProvider router={router}/>
}

export default App;