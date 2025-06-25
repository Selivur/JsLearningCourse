import Sidebar from "@/shared/ui/Sidebar/Sidebar";

export default function LessonLayout({ children }: { children: React.ReactNode }) {
  return (
    <div className="flex h-screen">
      <div className="fixed top-0 left-0 bottom-0 z-10">
        <Sidebar />
      </div>
      <div className="flex-1 ml-80">
        {children}
      </div>
    </div>
  );
} 