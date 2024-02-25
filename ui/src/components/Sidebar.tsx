import { useEffect, useRef } from 'react';
import { NavLink, useLocation } from 'react-router-dom';
import Logo from './../../public/vite.svg';

interface SidebarProps {
    sidebarOpen: boolean;
    setSidebarOpen: (arg: boolean) => void;
}

const Sidebar = ({ sidebarOpen, setSidebarOpen }: SidebarProps) => {
    const location = useLocation();
    const { pathname } = location;
    
    const trigger = useRef<any>(null);
    const sidebar = useRef<any>(null);

   
    // close on click outside
    useEffect(() => {
        const clickHandler = ({ target }: MouseEvent) => {
            if (!sidebar.current || !trigger.current) return;
            if (
                !sidebarOpen ||
                sidebar.current.contains(target) ||
                trigger.current.contains(target)
            )
                return;
            setSidebarOpen(false);
        };
        document.addEventListener('click', clickHandler);
        return () => document.removeEventListener('click', clickHandler);
    });

    // close if the esc key is pressed
    useEffect(() => {
        const keyHandler = ({ keyCode }: KeyboardEvent) => {
            if (!sidebarOpen || keyCode !== 27) return;
            setSidebarOpen(false);
        };
        document.addEventListener('keydown', keyHandler);
        return () => document.removeEventListener('keydown', keyHandler);
    });

 

    return (
        <aside
            ref={sidebar}
            className={`absolute left-0 top-0 z-9999 flex h-screen w-72.5 flex-col overflow-y-hidden bg-black duration-300 ease-linear dark:bg-boxdark lg:static lg:translate-x-0 ${sidebarOpen ? 'translate-x-0' : '-translate-x-full'
                }`}
        >
            {/* <!-- SIDEBAR HEADER --> */}
            <div className="flex items-center justify-between gap-4 px-4 py-2.5 lg:py-2.5">
                <NavLink to="/">
                    <img src={Logo} alt="Logo" />
                </NavLink>

            </div>
            {/* <!-- SIDEBAR HEADER --> */}

            <div className="no-scrollbar flex flex-col overflow-y-auto duration-300 ease-linear">
                {/* <!-- Sidebar Menu --> */}
                <nav className="mt-2 py-2 px-2 lg:mt-2 lg:px-6">
                    {/* <!-- Menu Group --> */}
                    <div>
                        <h3 className="text-title-md mb-4 ml-4 text-sm font-semibold text-bodydark2">
                           DashBoard Investimentos
                        </h3>

                        <ul className="mb-6 flex text-lg flex-col gap-1.5">
                            <li>
                                <NavLink
                                    to="/"
                                    className={`group relative flex items-center gap-2.5 rounded-sm py-2 px-3 font-medium text-bodydark1 duration-300 ease-in-out hover:bg-graydark dark:hover:bg-meta-4 ${pathname.includes('chart') && 'bg-graydark dark:bg-meta-4'
                                        }`}
                                >
                                    <svg xmlns="http://www.w3.org/2000/svg" fill="#ffffff" width="44px" height="44px" viewBox="0 -8 60 70" id="Layer_1" ><title>train</title><path d="M52.82,20.74,39.31,18.49a24.46,24.46,0,0,0-6.62,0L19.18,20.74a4.1,4.1,0,0,0-3.3,3.91V34.71a3.36,3.36,0,0,0,3.35,3.35v3.36L24.6,44.1,19.23,54.83H52.77L47.4,44.1l5.37-2.68V38.06a3.36,3.36,0,0,0,3.35-3.35V24.65A4.1,4.1,0,0,0,52.82,20.74ZM36,21.29a3.36,3.36,0,1,1-3.35,3.36A3.35,3.35,0,0,1,36,21.29ZM29.29,41.42H42.71l1.68,3.35H27.61ZM47.74,51.48H24.26l1.68-3.36H46.06Z" /><path d="M36,15a17.93,17.93,0,0,1,3.29.27l13.48,2.7V11.23c0-3.7-7.51-6.71-16.77-6.71s-16.77,3-16.77,6.71v6.71l13.48-2.7A17.93,17.93,0,0,1,36,15ZM39.35,8c6.09.54,9.56,2.43,10.07,3.32v2.5L40,12l-.6-.08Zm-6.7,3.84-.6.08-9.47,1.9v-2.5c.51-.89,4-2.78,10.07-3.32Z" /><circle cx="27.61" cy="2.84" r="1.68" /><circle cx="44.39" cy="2.84" r="1.68" /></svg>
                                    Painel
                                </NavLink>
                            </li>

                            <li>
                                <NavLink
                                    to="/fii"
                                    className={`group relative flex items-center gap-2.5 rounded-sm py-2 px-4 font-medium text-bodydark1 duration-300 ease-in-out hover:bg-graydark dark:hover:bg-meta-4 ${pathname.includes('chart') && 'bg-graydark dark:bg-meta-4'
                                        }`}
                                >
                                    <svg xmlns="http://www.w3.org/2000/svg" width="45px" height="45px"  xmlnsXlink="http://www.w3.org/1999/xlink" fill="#ffffff" version="1.1" id="Capa_1"  viewBox="2 0 25 25" xmlSpace="preserve">
                                        <g>
                                            <g>
                                                <g>
                                                   
                                                    <path d="M12.849,20.742c4.61,0,8.348-0.45,8.348-1.01c0-0.029-0.442-0.652-0.855-1.229c2.933-0.05,5.217-0.445,5.217-0.927     c0-0.013-5.186-7.367-6.614-9.396c-0.082-0.117-0.218-0.187-0.36-0.188c-0.144,0-0.279,0.07-0.362,0.187l-1.804,2.551     L13.24,4.668c-0.078-0.145-0.228-0.236-0.392-0.236c-0.165,0-0.315,0.091-0.393,0.236C10.802,7.788,4.5,19.685,4.5,19.731    " />
                                                </g>
                                            </g>
                                        </g>
                                    </svg>

                                    Fii's
                                </NavLink>
                            </li>

                            <li>
                                <NavLink
                                    to="/acoes"
                                    className={`group relative flex items-center gap-2.5 rounded-sm py-2 px-4 font-medium text-bodydark1 duration-300 ease-in-out hover:bg-graydark dark:hover:bg-meta-4 ${pathname.includes('chart') && 'bg-graydark dark:bg-meta-4'
                                        }`}
                                >
                                    <svg xmlns="http://www.w3.org/2000/svg"
                                        width="42px"
                                        height="40px"
                                        viewBox="0 0 400 512">
                                        <path
                                        fill="#ffffff"
                                        d="M317.727 108.904l-95.192 96.592-26.93 86.815 17.54 36.723 20.417 9.287 33.182-55.082 11.297-3.61 61.75 26.85 20.26-12.998 4.47-43.7 11.42 53.634-10.622 14.162 3.772 1.64 5.238 6.5 6.832 34.343 55.977-66.775 13.98.23 22.397 28.575-9.453-52.244L434.01 166.81l-116.28-57.906zM123.61 120.896L94.08 173l-4.603 27.62 25.98-8.442 11.704 7.377.084.634 28.295 59.865 13.773-4.543 10.94 4.668 3.922 8.21 19.517-62.917-1.074-33.336-40.15-.522-29.732-23.78 34.06 10.888 42.49-7.727 26.034 15.88 36.282-36.815c-2.777-1.18-5.615-2.356-8.58-3.52l-79.58 10.126-3.528-.25-56.307-15.52zm249.33 36.422l47.058 66.02 2.107 62.51-25.283-59.698-65.322-60.404 41.44-8.428zm-262.2 55.32l-64.234 20.876-16.71 78.552 50.794 5.582.596-7.14 37.662-36.707-8.108-61.16zm56.688 62.45l-36.44 12.016-31.644 30.84 22.588 30.867 57.326 1.74 16.5-16.16-28.33-59.302zm110.666 24.19l-44.307 73.546-.033 57.14 97.264 12.216 44.242-19.528-17.666-88.806-79.5-34.567zM443.8 313.36l-46.843 55.876.287 1.774 65.147 13.887 25.78-14.926-44.37-56.613zm-138.382 15.89l39.23 22.842 13.41 50.658-26.82 23.838-45.015-2.553 38.562-28.242 2.483-39.23-21.85-27.312zm-238.37 53.838l-8.77 28.51 13.152 48.498 91.037-11.91 1.32-26.418-62.582-31.995-34.156-6.684z" />
                                    </svg>
                                    Ações
                                </NavLink>
                            </li>

                        </ul>
                    </div>

                    
                    
                    : <></>
                   
                </nav>
                {/* <!-- Sidebar Menu --> */}
            </div>
            <div style={{ display: "flex", flexDirection: "column", flex: 1} }>
                <div style={{ marginTop: "auto" } }>Developed By Matheus Sampaio - Reacher's Tech</div>
            </div>
        </aside>
    );
};

export default Sidebar;
