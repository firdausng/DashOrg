import {Route} from "@tanstack/react-router";
import {rootRoute} from "../route.tsx";
import Index from "./index.tsx";

const indexRoute = new Route({
    getParentRoute: () => rootRoute,
    path: '/',
    component: Index,
})
export default indexRoute;