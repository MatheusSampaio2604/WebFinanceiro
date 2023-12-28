import { Button } from "@material-tailwind/react";
import Tooltip from "@mui/material/Tooltip/Tooltip";
import dayjs from 'dayjs';
import DateTimerPicker from '../../componentsGTA/DateTimerPicker';

interface Props {
    dashMode: string;
    dateMode: string;
    handleDateMode: any;
    handleDateBeginChange: any;
    handleDateEndChange: any;
    handleModeChanged: any;
    handleClickButton: any;
}

const TogleDash = ({ handleDateBeginChange, handleDateEndChange, handleModeChanged, handleClickButton, dashMode, dateMode, handleDateMode }: Props) => {
    return (
        <div className="flex -mt-4 -ml-4 text-white px-2 py-2 rounded-lg mb-2 mx-2 text-title-lg font-bold">

            <Tooltip title={dateMode === 'only' ? 'Data' : 'Entre datas'}>
                <label
                    className={`relative m-0 block h-7.5 w-14 mr-4 rounded-full ${dateMode === 'only' ? 'bg-primary' : 'bg-meta-5/40'
                        }`}
                >
                    <input
                        type="checkbox"
                        onChange={handleDateMode}
                        className="dur absolute top-0 z-50 m-0 h-full w-full cursor-pointer opacity-0"
                    />
                    <span
                        className={`absolute top-1/2 left-[3px] flex h-6 w-6 -translate-y-1/2 translate-x-0 items-center justify-center rounded-full bg-white shadow-switcher duration-75 ease-linear ${dateMode === 'only' && '!right-[3px] !translate-x-full'
                            }`}
                    >
                        <span className={`${dateMode === 'between' ? '' : 'hidden'}`} >
                            <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" fill="none">
                                <path d="M22 12H2M22 12L18 16M22 12L18 8M2 12L6 16M2 12L6 8" stroke="#000000" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round" />
                            </svg>
                        </span>
                        <span className={`${dateMode === 'only' ? '' : 'hidden'}`} >
                            <svg xmlns="http://www.w3.org/2000/svg" xmlnsXlink="http://www.w3.org/1999/xlink" height="20px" width="20px" version="1.1" id="_x32_" viewBox="0 0 512 512" xmlSpace="preserve">
                                <style type="text/css">

                                </style>
                                <g>
                                    <path className="st0" d="M463.515,236.436c-4.627-49.732-26.735-94.499-60.104-127.839c-33.341-33.369-78.115-55.484-127.846-60.112V0   h-39.129v48.485c-49.717,4.627-94.491,26.742-127.831,60.112c-33.37,33.34-55.477,78.108-60.12,127.839H0v39.129h48.484   c4.643,49.732,26.75,94.498,60.12,127.838c33.34,33.362,78.114,55.477,127.831,60.112V512h39.129v-48.484   c49.731-4.636,94.505-26.75,127.846-60.112c33.369-33.34,55.477-78.107,60.104-127.838H512v-39.129H463.515z M422.953,275.565   c-4.47,38.62-21.964,73.172-48.069,99.312c-26.148,26.112-60.692,43.592-99.32,48.07v-69.339h-39.129v69.332   c-38.613-4.47-73.172-21.95-99.305-48.062c-26.119-26.14-43.599-60.692-48.069-99.312h69.332v-39.129H89.061   c4.47-38.621,21.95-73.172,48.069-99.313c26.134-26.112,60.692-43.599,99.305-48.069v69.339h39.129V89.054   c38.627,4.47,73.171,21.957,99.32,48.069c26.105,26.141,43.599,60.692,48.069,99.313h-69.346v39.129H422.953z" />
                                    <path className="st0" d="M256.007,233.993C243.843,233.993,234,243.85,234,256c0,12.15,9.843,22.007,22.008,22.007   c12.15,0,22.007-9.858,22.007-22.007C278.014,243.85,268.157,233.993,256.007,233.993z" />
                                </g>
                            </svg>
                        </span>
                    </span>
                </label>
            </Tooltip>
            {dateMode === 'only' ? < div className="-mt-3"> <DateTimerPicker handleDateChange={handleDateBeginChange} type="selectedDateBegin" /></div>
                : <><div className="text-title-md font-bold text-black  dark:text-white mx-2">Início</div>  <div className="-mt-3"> <DateTimerPicker handleDateChange={handleDateBeginChange} type="selectedDateBegin" maxDate={dayjs()} /></div> <div className="text-title-md font-bold text-black mx-2 dark:text-white">Fim</div> <div className="-mt-3"> <DateTimerPicker handleDateChange={handleDateEndChange} maxDate={dayjs()} type="selectedDateEnd" /></div></>}
            <Tooltip title={'Play'}>
                <label>
            <Button onClick={handleClickButton} className="mx-3">
                <svg xmlns="http://www.w3.org/2000/svg" xmlnsXlink="http://www.w3.org/1999/xlink" width="20px" height="20px" viewBox="-0.5 0 7 7" version="1.1">
                    <g id="Page-1" stroke="none" strokeWidth="1" fill="none" fillRule="evenodd">
                        <g id="Dribbble-Light-Preview" transform="translate(-347.000000, -3766.000000)" fill="#000000">
                            <g id="icons" transform="translate(56.000000, 160.000000)">
                                <path d="M296.494737,3608.57322 L292.500752,3606.14219 C291.83208,3605.73542 291,3606.25002 291,3607.06891 L291,3611.93095 C291,3612.7509 291.83208,3613.26444 292.500752,3612.85767 L296.494737,3610.42771 C297.168421,3610.01774 297.168421,3608.98319 296.494737,3608.57322" id="play-[#1003]">

                                </path>
                            </g>
                        </g>
                    </g>
                        </svg>
               
                    </Button>
                </label>
            </Tooltip>
        </div>
    );
}

export default TogleDash;