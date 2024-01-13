import {Link, Outlet, RootRoute} from "@tanstack/react-router";
import {TanStackRouterDevtools} from "@tanstack/router-devtools";
import aboutRoute from "./routes/about/route.tsx";
import indexRoute from "./routes/route.tsx";

export const rootRoute = new RootRoute({
    component: () => (
        <>
            <div className="p-2 flex gap-2 ">
                <Link to={'/'} className="[&.active]:font-bold">
                    Home
                </Link>{' '}
                <Link to="/about" className="[&.active]:font-bold">
                    About
                </Link>
            </div>
            <hr/>
            <Outlet/>
            <TanStackRouterDevtools/>
        </>
    ),
});

const routeTree
    = rootRoute.addChildren([indexRoute, aboutRoute])

export default routeTree;