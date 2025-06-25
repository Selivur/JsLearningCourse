export default function Loader() {
  return (
    <div className="flex items-center justify-center min-h-screen bg-slate-100">
      <div className="flex flex-col items-center">
        <span className="relative flex h-12 w-12 mb-4">
          <span className="animate-ping absolute inline-flex h-full w-full rounded-full bg-orange-400 opacity-75"></span>
          <span className="relative inline-flex rounded-full h-12 w-12 bg-orange-600"></span>
        </span>
        <span className="text-slate-700 text-lg font-medium">
          Завантаження...
        </span>
      </div>
    </div>
  );
}
