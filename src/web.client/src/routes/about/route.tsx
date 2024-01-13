import {Route} from "@tanstack/react-router";
import {About} from "./about.tsx";
import { rootRoute } from "../../route.tsx";

const aboutRoute = new Route({
    getParentRoute: () => rootRoute,
    path: '/about',
    component: About,
})

export default aboutRoute;